CREATE TABLE IF NOT EXISTS RgfOidcTokenCache (
    Id text PRIMARY KEY,
    Value bytea NOT NULL,
    ExpiresAtTime timestamptz NOT NULL,
    SlidingExpirationInSeconds bigint NULL,
    AbsoluteExpiration timestamptz NULL
);
/*$$*/

DROP VIEW IF EXISTS v_employee;
/*$$*/

CREATE VIEW v_employee AS
    SELECT
        CONCAT(e1.FirstName, ' ', e1.LastName) AS EmployeeName,
        (SELECT COUNT(*) FROM orders WHERE EmployeeId = e1.EmployeeId) AS OrdersCount,
        e1.*
    FROM employees e1;
/*$$*/
