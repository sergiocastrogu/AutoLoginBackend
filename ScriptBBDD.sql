CREATE DATABASE AutoLogin;


CREATE TABLE Persons (
person_id BIGINT PRIMARY KEY IDENTITY(1,1),
identification NVARCHAR(20) NOT NULL UNIQUE,
first_name NVARCHAR(50) NOT NULL,
second_name NVARCHAR(50),
first_last_name NVARCHAR(50) NOT NULL,
second_last_name NVARCHAR(50),
phone NVARCHAR(15) ,
email NVARCHAR(100) not null UNIQUE
)

CREATE TABLE Users (
user_id BIGINT PRIMARY KEY IDENTITY(1,1),
person_id BIGINT NOT NULL,
user_name NVARCHAR(100) NOT NULL UNIQUE,
password NVARCHAR(255) NOT NULL,
status bit not null
CONSTRAINT FQ_User_Person FOREIGN KEY (person_id) References Persons(person_id)
)

