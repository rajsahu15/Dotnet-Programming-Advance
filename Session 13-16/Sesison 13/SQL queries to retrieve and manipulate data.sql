use PracticeModule;
CREATE TABLE Doctor (
    doc_id INT PRIMARY KEY,
    docname VARCHAR(50) UNIQUE NOT NULL,
    dpass VARCHAR(255) NOT NULL,
    dcity VARCHAR(100)
);

-- Insert 5 doctor entries
INSERT INTO Doctor (doc_id, docname, dpass, dcity) VALUES
(1, 'Dr. Raj Patel', 'pass123hashed', 'Indore'),
(2, 'Dr. Priya Sharma', 'secure456', 'Bhopal'),
(3, 'Dr. Amit Singh', 'doctor789', 'Mumbai'),
(4, 'Dr. Neha Gupta', 'health2026', 'Delhi'),
(5, 'Dr. Vikram Joshi', 'medpass999', 'Pune');

select *from Doctor;

-- SQL queries to retrieve and manipulate data --

-- Doctors from specific city
SELECT * FROM Doctor WHERE dcity = 'Indore';

-- Doctors with specific password pattern
SELECT docname, dcity FROM Doctor WHERE dpass LIKE '%123%';

-- Doctors from Indore or Bhopal
SELECT * FROM Doctor WHERE dcity IN ('Indore', 'Bhopal');

-- Top 3 doctors by name
SELECT TOP 3 * FROM Doctor ORDER BY docname ASC;

-- Cities with more than 1 doctor
SELECT dcity, COUNT(doc_id) as total_docs
FROM Doctor 
GROUP BY dcity 
HAVING COUNT(doc_id) >= 1;

-- Add new column
ALTER TABLE Doctor ADD phone VARCHAR(15);

-- Drop column
ALTER TABLE Doctor DROP COLUMN phone;

-- UPDATE doctor password
UPDATE Doctor SET dpass = 'new_secure_pass456' WHERE doc_id = 1;

-- Update city for specific doctor
UPDATE Doctor SET dcity = 'Nagpur' WHERE docname = 'Dr. Raj Patel';

-- DELETE specific doctor
DELETE FROM Doctor WHERE doc_id = 5;

-- Insert new doctor
INSERT INTO Doctor (doc_id, docname, dpass, dcity) 
VALUES (6, 'Dr. Anjali Rao', 'docpass2026', 'Indore');

select *from Doctor;