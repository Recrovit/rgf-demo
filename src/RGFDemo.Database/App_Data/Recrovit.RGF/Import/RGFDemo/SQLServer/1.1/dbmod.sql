CREATE TABLE [RgfOidcTokenCache](
	[Id] [nvarchar](449) NOT NULL,
	[Value] [varbinary](max) NOT NULL,
	[ExpiresAtTime] [datetimeoffset](7) NOT NULL,
	[SlidingExpirationInSeconds] [bigint] NULL,
	[AbsoluteExpiration] [datetimeoffset](7) NULL,
	PRIMARY KEY CLUSTERED (	[Id] ASC)
)
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[v_employee]'))
	DROP VIEW [v_employee]
GO

CREATE VIEW [v_employee] as
    SELECT 
           (Concat(e1.FirstName, ' ', e1.LastName)) as EmployeeName,
           (select count(*) from orders where EmployeeId=e1.EmployeeId) as OrdersCount,
		   e1.*
    FROM Employees e1
GO
