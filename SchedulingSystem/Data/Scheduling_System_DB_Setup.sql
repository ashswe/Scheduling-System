-- Scheduling Software Database

DROP DATABASE IF EXISTS scheduling_software;
CREATE DATABASE scheduling_software;
USE scheduling_software;

-- Disable FK checks while rebuilding tables
SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS appointment;
DROP TABLE IF EXISTS customer;
DROP TABLE IF EXISTS address;
DROP TABLE IF EXISTS city;
DROP TABLE IF EXISTS country;
DROP TABLE IF EXISTS user;

SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE country (
    countryId INT(10) NOT NULL AUTO_INCREMENT,
    country VARCHAR(50) NOT NULL,
    createDate DATETIME NOT NULL DEFAULT NOW(),
    createdBy VARCHAR(40) NOT NULL,
    lastUpdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(40) NOT NULL,
    PRIMARY KEY (countryId)
)

CREATE TABLE city (
    cityId INT(10) NOT NULL AUTO_INCREMENT,
    city VARCHAR(50) NOT NULL,
    countryId INT(10) NOT NULL,
    createDate DATETIME NOT NULL DEFAULT NOW(),
    createdBy VARCHAR(40) NOT NULL,
    lastUpdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(40) NOT NULL,
    PRIMARY KEY (cityId),
    CONSTRAINT fk_city_country
        FOREIGN KEY (countryId) REFERENCES country(countryId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) 

CREATE TABLE address (
    addressId INT(10) NOT NULL AUTO_INCREMENT,
    address VARCHAR(50) NOT NULL,
    address2 VARCHAR(50) NOT NULL,
    cityId INT(10) NOT NULL,
    postalCode VARCHAR(10) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    createDate DATETIME NOT NULL DEFAULT NOW(),
    createdBy VARCHAR(40) NOT NULL,
    lastUpdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(40) NOT NULL,
    PRIMARY KEY (addressId),
    CONSTRAINT fk_address_city
        FOREIGN KEY (cityId) REFERENCES city(cityId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
)

CREATE TABLE customer (
    customerId INT(10) NOT NULL AUTO_INCREMENT,
    customerName VARCHAR(45) NOT NULL,
    addressId INT(10) NOT NULL,
    active TINYINT(1) NOT NULL DEFAULT 1,
    createDate DATETIME NOT NULL DEFAULT NOW(),
    createdBy VARCHAR(40) NOT NULL,
    lastUpdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(40) NOT NULL,
    PRIMARY KEY (customerId),
    CONSTRAINT fk_customer_address
        FOREIGN KEY (addressId) REFERENCES address(addressId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
)

CREATE TABLE user (
    userId INT NOT NULL AUTO_INCREMENT,
    userName VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    active TINYINT NOT NULL DEFAULT 1,
    createDate DATETIME NOT NULL DEFAULT NOW(),
    createdBy VARCHAR(40) NOT NULL,
    lastUpdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(40) NOT NULL,
    PRIMARY KEY (userId),
    UNIQUE KEY uq_user_userName (userName)
)

CREATE TABLE appointment (
    appointmentId INT(10) NOT NULL AUTO_INCREMENT,
    customerId INT(10) NOT NULL,
    userId INT NOT NULL,
    title VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    location TEXT NOT NULL,
    contact TEXT NOT NULL,
    type TEXT NOT NULL,
    url VARCHAR(255) NOT NULL,
    start DATETIME NOT NULL,
    end DATETIME NOT NULL,
    createDate DATETIME NOT NULL DEFAULT NOW(),
    createdBy VARCHAR(40) NOT NULL,
    lastUpdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    lastUpdateBy VARCHAR(40) NOT NULL,
    PRIMARY KEY (appointmentId),
    CONSTRAINT fk_appointment_customer
        FOREIGN KEY (customerId) REFERENCES customer(customerId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,
    CONSTRAINT fk_appointment_user
        FOREIGN KEY (userId) REFERENCES user(userId)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) 

