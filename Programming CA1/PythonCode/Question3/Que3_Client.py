import socket
import json

print(" ===== DBS ADMISSION PORTAL ===== ")

name = input("Enter your Name: ")
address = input("Enter your Address: ")
qualification = input("Enter your Educational Qualification: ")

print("\nAvailable Courses:")
print("1. MSc in Cyber Security")
print("2. MSc Information Systems & Computing")
print("3. MSc Data Analytics")

course_choice = input("Choose (1-3):")

courses = {
    "1": "MSc in Cyber Security",
    "2": "MSc Information Systems & Computing",
    "3": "MSc Data Analytics",
}

course = courses.get(course_choice, "Unknown Course")

start_year = int(input("Enter start Year: "))
start_month = int(input("Enter start Month (1-12): "))

data = {
    "name": name,
    "address": address,
    "qualification": qualification,
    "course": course,
    "start_year": start_year,
    "start_month": start_month,
}

data_json = json.dumps(data)

client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(("127.0.0.1", 5001))

client.send(data_json.encode())

app_number = client.recv(1024).decode()

print("\nYour Application is Submitted Successfully!")
print("Your Registration Number is:", app_number)

client.close()
