import socket
import json
from sqlalchemy import create_engine, Column, Integer, String
from sqlalchemy.orm import sessionmaker, declarative_base

DATABASE_URL = "mysql+pymysql://finance_user:StrongPassword123@localhost/admission_db"

engine = create_engine(DATABASE_URL, echo=True)
Session = sessionmaker(bind=engine)
session = Session()

Base = declarative_base()


class Applicant(Base):
    __tablename__ = "applicants"

    id = Column(Integer, primary_key=True, autoincrement=True)
    name = Column(String(100))
    email = Column(String(150))
    course = Column(String(100))
    phone = Column(String(20))


Base.metadata.create_all(engine)

print("Connected to MySQL using SQLAlchemy successfully!")

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(("127.0.0.1", 5001))
server.listen(5)

print("SERVER RUNNING... Waiting for client connection...")

while True:
    conn, addr = server.accept()
    print("Connected with:", addr)

    data = conn.recv(4096).decode()
    applicant_data = json.loads(data)

    new_applicant = Applicant(
        name=applicant_data.get("name"),
        email=applicant_data.get("email"),
        course=applicant_data.get("course"),
        phone=applicant_data.get("phone"),
    )

    session.add(new_applicant)
    session.commit()

    registration_number = str(new_applicant.id)

    conn.send(registration_number.encode())
    conn.close()
