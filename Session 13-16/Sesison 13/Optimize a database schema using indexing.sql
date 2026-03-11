USE PracticeModule;

-- Optimized Doctor table with recommended indexes
CREATE TABLE Doctor2 (
    doc_id INT IDENTITY(1,1) PRIMARY KEY,  -- Clustered index (auto-increment)
    docname VARCHAR(50) UNIQUE NOT NULL,
    dpass VARCHAR(255) NOT NULL,
    dcity VARCHAR(100)
);

-- 1. Non-clustered index on docname (UNIQUE constraint already creates it)
-- 2. Non-clustered index on dcity (most common WHERE clause)
CREATE NONCLUSTERED INDEX IX_Doctor_dcity ON Doctor2(dcity);

-- 3. Covering index for common login queries (docname + dpass)
CREATE NONCLUSTERED INDEX IX_Doctor_Login 
ON Doctor2(docname) INCLUDE (dpass, dcity);


INSERT INTO Doctor2 (docname, dpass, dcity) VALUES
('Dr. Raj Patel', 'pass123hashed', 'Indore'),
('Dr. Priya Sharma', 'secure456', 'Bhopal'),
('Dr. Amit Singh', 'doctor789', 'Mumbai'),
('Dr. Neha Gupta', 'health2026', 'Delhi'),
('Dr. Vikram Joshi', 'medpass999', 'Pune');

-- View all indexes on Doctor table
SELECT 
    i.name AS IndexName,
    i.type_desc AS IndexType,
    c.name AS ColumnName
FROM sys.indexes i
JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE i.object_id = OBJECT_ID('Doctor2');

-- This will now use IX_Doctor_dcity index (much faster)
SET STATISTICS IO ON;
SELECT * FROM Doctor2 WHERE dcity = 'Indore';
SET STATISTICS IO OFF;
