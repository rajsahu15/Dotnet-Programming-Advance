use PracticeModule;

CREATE TABLE library (
    library_id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE users (
    user_id INT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    name VARCHAR(100)
);

CREATE TABLE books (
    book_id INT PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    author VARCHAR(100),
    isbn VARCHAR(20) UNIQUE,
    library_id INT,
    FOREIGN KEY (library_id) REFERENCES library(library_id)
);

CREATE TABLE issues (
    issue_id INT PRIMARY KEY ,
    user_id INT,
    book_id INT,
    library_id INT,
    issue_date DATE NOT NULL,
    return_date DATE,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (book_id) REFERENCES books(book_id),
    FOREIGN KEY (library_id) REFERENCES library(library_id)
);
-- Insert library branches first
INSERT INTO library (library_id, name) VALUES 
(1, 'Central Library'),
(2, 'North Branch'),
(3, 'South Branch');

-- Insert users next
INSERT INTO users (user_id, username, password, name) VALUES 
(1, 'raj_sahu', 'hashedpass123', 'Raj Sahu'),
(2, 'priya_user', 'secure456', 'Priya Sharma'),
(3, 'admin_lib', 'admin789', 'Library Admin');

-- Insert books (linked to libraries)
INSERT INTO books (book_id, name, author, isbn, library_id) VALUES 
(1, 'To Kill a Mockingbird', 'Harper Lee', '9780446310789', 1),
(2, '1984', 'George Orwell', '9780451524935', 1),
(3, 'Sapiens', 'Yuval Noah Harari', '9780062316097', 2),
(4, 'The Alchemist', 'Paulo Coelho', '9780062315007', 2),
(5, 'Atomic Habits', 'James Clear', '9780735211292', 3);

-- Insert book issues (links user, book, and library)
INSERT INTO issues (issue_id, user_id, book_id, library_id, issue_date, return_date) VALUES 
(1, 1, 1, 1, '2026-02-15', NULL),
(2, 2, 3, 2, '2026-02-20', '2026-03-05'),
(3, 1, 4, 2, '2026-02-25', NULL),
(4, 3, 2, 1, '2026-03-01', NULL);

select *from issues;
select *from books;
select *from library;
select *from users;