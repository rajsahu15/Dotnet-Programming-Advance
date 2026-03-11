
use PracticeModule;
CREATE TABLE EMPForView (
    EMPLOYEE_ID     INT             NOT NULL PRIMARY KEY,      
    FIRST_NAME      NVARCHAR(20),                              
    LAST_NAME       NVARCHAR(25)    NOT NULL,                  
    EMAIL           NVARCHAR(25)    NOT NULL UNIQUE,           
    PHONE_NUMBER    NVARCHAR(20),                             
    HIRE_DATE       DATETIME2       NOT NULL,                   
    JOB_ID          NVARCHAR(10)    NOT NULL,                   
    SALARY          DECIMAL(8,2),                             
    COMMISSION_PCT  DECIMAL(4,2),                             
    MANAGER_ID      INT,                                       
    DEPARTMENT_ID   SMALLINT                                
);


INSERT INTO EMPForView(EMPLOYEE_ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, HIRE_DATE, JOB_ID, SALARY, COMMISSION_PCT, MANAGER_ID, DEPARTMENT_ID) VALUES
(100, 'Steven', 'King', 'SKING', '515.123.4567', '1987-06-17T00:00:00', 'AD_PRES', 24000.00, NULL, NULL, 90),
(101, 'Neena', 'Kochhar', 'NKOCHHAR', '515.123.4568', '1989-09-21T00:00:00', 'AD_VP', 17000.00, NULL, 100, 90),
(102, 'Lex', 'De Haan', 'LDEHAAN', '515.123.4569', '1993-01-13T00:00:00', 'AD_VP', 17000.00, NULL, 100, 90),
(103, 'Alexander', 'Hunold', 'AHUNOLD', '590.423.4567', '1990-01-03T00:00:00', 'IT_PROG', 9000.00, NULL, 102, 60),
(104, 'Bruce', 'Ernst', 'BERNST', '590.423.4568', '1991-12-03T00:00:00', 'IT_PROG', 6000.00, NULL, 103, 60),
(105, 'David', 'Austin', 'DAUSTIN', '590.423.4569', '1997-06-25T00:00:00', 'IT_PROG', 4800.00, NULL, 103, 60),
(106, 'Valli', 'Pataballa', 'VPATABAL', '590.423.4560', '1998-02-05T00:00:00', 'IT_PROG', 4800.00, NULL, 103, 60),
(107, 'Diana', 'Lorentz', 'DLORENTZ', '590.423.5567', '1999-02-07T00:00:00', 'IT_PROG', 4200.00, NULL, 103, 60);


select *from EMPForView;


--check view Defination--
sp_helptext 'highSalaryView';

--modify a view --
ALTER VIEW highSalaryView
AS
SELECT EMPLOYEE_ID, FIRST_NAME, LAST_NAME, SALARY, DEPARTMENT_ID
FROM EMPForView
WHERE SALARY > 8000;

