use PracticeModule;

Create PROCEDURE empSalaryGreaterThan
    @salary DECIMAL(8,2)
AS
BEGIN
    SELECT EMPLOYEE_ID, FIRST_NAME, LAST_NAME, SALARY
    FROM EMP
    WHERE SALARY > @salary;
END;

EXEC empSalaryGreaterThan 10000;