use PracticeModule;
CREATE TABLE car_sales (
    -- Numeric types
    sale_id INT IDENTITY(1,1) PRIMARY KEY,
    car_id INT NOT NULL,
    quantity TINYINT NOT NULL,           -- 1-255 cars
    price DECIMAL(12,2) NOT NULL,        -- 12345678.99
    discount_rate FLOAT(24),             -- 0.15 (15%)
    tax_amount MONEY,                    -- 99999999.9999
    
    -- String types
    car_name NVARCHAR(100) NOT NULL,
    model VARCHAR(50) NOT NULL,
    brand NCHAR(20) NOT NULL,            -- Fixed brand length
    customer_name NVARCHAR(150),
    notes VARCHAR(MAX),                  -- Long descriptions
    
    -- Date/Time types
    purchase_date DATE NOT NULL,         -- 2026-03-03
    purchase_time TIME(3) NOT NULL,      -- 14:30:45.123
    delivery_datetime DATETIME2(2),      -- 2026-03-10 09:15:30.75
    warranty_end DATETIME,               -- Legacy format
    
    -- Special types
    is_financed BIT NOT NULL DEFAULT 0,  -- 0/1 boolean
    sales_rep_id SMALLINT,               -- Manager reference
  
);

INSERT INTO car_sales (
    car_id, quantity, price, discount_rate, tax_amount,
    car_name, model, brand, customer_name, notes,
    purchase_date, purchase_time, delivery_datetime, warranty_end,
    is_financed, sales_rep_id
) VALUES

(1, 1, 2850000.00, 0.05, 142500.00,
 'Toyota Camry', 'XLE 2026', 'TOYOTA     ', 'Raj Sahu', 'Premium audio package upgraded',
 '2026-03-03', '14:30:25.500', '2026-03-10 09:15:30.75', '2027-03-03 00:00:00',
 1, 2),

(2, 1, 1520000.00, 0.08, 76000.00,
 'Honda City', 'ZX CVT', 'HONDA      ', 'Priya Sharma', 'Full protection package',
 '2026-03-02', '11:45:12.000', '2026-03-09 16:30:00.00', '2027-03-02 00:00:00',
 1, 3),

(3, 2, 850000.00, 0.00, 42500.00,
 'Swift', 'ZXi+', 'MARUTI     ', 'Amit Patel', NULL,
 '2026-03-03', '09:20:45.250', NULL, '2027-03-03 00:00:00',
 0, 4),

(4, 1, 2150000.00, 0.03, 107500.00,
 'Creta', 'SX Tech', 'HYUNDAI    ', 'Neha Gupta', 'Panoramic sunroof added',
 '2026-03-01', '16:15:30.750', '2026-03-08 14:45:15.25', '2027-03-01 00:00:00',
 0, 2),

(5, 3, 1250000.00, 0.10, 37500.00,
 'Nexon', 'Creative+', 'TATA       ', 'Corporate Fleet', 'Company lease - 3 units',
 '2026-03-03', '17:25:08.000', '2026-03-12 10:00:00.00', '2027-03-03 00:00:00',
 1, 1);

 select *from car_sales;