
CREATE TABLE employees2(
    empid INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    dept VARCHAR(50) NOT NULL,
    loc VARCHAR(50) NOT NULL,
    phone VARCHAR(15),
    manager INT
);
INSERT INTO employees2 (empid, name, dept, loc, phone, manager) VALUES
(1, 'Alice Johnson', 'Executive', 'HQ', '123-456-7890', NULL),
(2, 'Bob Smith', 'Engineering', 'HQ', '234-567-8901', 1),
(3, 'Carol Lee', 'HR', 'Branch1', '345-678-9012', 1),
(4, 'David Kim', 'Engineering', 'Branch1', '456-789-0123', 2),
(5, 'Eva Patel', 'Engineering', 'Branch1', '567-890-1234', 2),
(6, 'Frank Wong', 'HR', 'HQ', '678-901-2345', 3);

select *from employees2;