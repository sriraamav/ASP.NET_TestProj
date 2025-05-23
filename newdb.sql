CREATE DATABASE IF NOT EXISTS organisation_db;
USE organisation_db;

CREATE TABLE IF NOT EXISTS employee_db (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    phone VARCHAR(10),
    address VARCHAR(200),
    email VARCHAR(100)
);



INSERT INTO employee_db (id, name, phone, address, email) VALUES
(1, 'Alice Johnson', '9443171123', '123 Main St, Springfield', 'alice.johnson@example.com'),
(2, 'Bob Smith', '9443171124', '456 Oak Ave, Rivertown', 'bob.smith@example.com'),
(3, 'Charlie Brown', '9443171789', '789 Pine Rd, Lakeview', 'charlie.brown@example.com'),
(4, 'Diana Prince', '9443173456', '101 Maple Ln, Metropolis', 'diana.prince@example.com'),
(5, 'Ethan Hunt', '9883171123', '202 Birch Blvd, Smallville', 'ethan.hunt@example.com'),
(6, 'Fiona Glenanne', '946771123', '303 Cedar Ct, Star City', 'fiona.glenanne@example.com'),
(7, 'George Miller', '7890123456', '404 Walnut Dr, Gotham', 'george.miller@example.com'),
(8, 'Hannah Wells', '8901234567', '505 Ash Ter, Central City', 'hannah.wells@example.com'),
(9, 'Ian Gallagher', '9012345678', '606 Elm Pl, Coast City', 'ian.gallagher@example.com'),
(10, 'Julia Stiles', '9653171123', '707 Fir Loop, Blüdhaven', 'julia.stiles@example.com');


SELECT * FROM employee_db;

DELIMITER //
CREATE PROCEDURE GetAllEmployees()
BEGIN
    SELECT * FROM employee_db;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE AddEmployee(
    IN emp_id INT,
    IN emp_name VARCHAR(100),
    IN emp_phone VARCHAR(10),
    IN emp_address VARCHAR(200),
    IN emp_email VARCHAR(100)
)
BEGIN
    INSERT INTO employee_db (id, name, phone, address, email)
    VALUES (emp_id, emp_name, emp_phone, emp_address, emp_email);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE EditEmployee(
    IN emp_id INT,
    IN emp_name VARCHAR(255),
    IN emp_phone VARCHAR(50),
    IN emp_address TEXT,
    IN emp_email VARCHAR(255)
)
BEGIN
    UPDATE employee_db
    SET name = emp_name,
        phone = emp_phone,
        address = emp_address,
        email = emp_email
    WHERE id = emp_id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE DeleteEmployee(
    IN emp_id INT
)
BEGIN
    DELETE FROM employee_db WHERE id = emp_id;
END //
DELIMITER ;




