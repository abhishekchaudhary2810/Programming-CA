from bs4 import BeautifulSoup
import csv


def scrape_hotel(file_path, hotel_name):
    rooms = []

    with open(file_path, "r", encoding="utf-8") as file:
        soup = BeautifulSoup(file.read(), "html.parser")

    rows = soup.find_all("tr")

    for row in rows[1:]:
        cols = row.find_all("td")
        room_type = cols[0].text.strip()
        price = cols[1].text.strip()
        season = cols[2].text.strip()
        rooms.append([hotel_name, room_type, price, season])
    return rooms


hotel1_file = "/Users/shellysiwach/Documents/Question4/hotel1.html"
hotel2_file = "/Users/shellysiwach/Documents/Question4/hotel2.html"

hotel1_data = scrape_hotel(hotel1_file, "Hotel Radisson")
hotel2_data = scrape_hotel(hotel2_file, "Hotel CNS")

all_data = hotel1_data + hotel2_data

csv_filename = "hotel_Data.csv"

with open(csv_filename, "w", newline="", encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["Hotel Name", "Room Type", "Price", "Season"])
    writer.writerows(all_data)

print("Data saved to hotel_prices.csv successfully!")

print("\nShowing all hotel data:\n")

with open(csv_filename, "r", encoding="utf-8") as file:
    reader = csv.reader(file)
    for row in reader:
        print(row)
