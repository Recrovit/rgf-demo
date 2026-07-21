RgfCmd.InitialCreate.ExecuteSQLFile Northwind.sql
GO

--RgfCmd.IfVersion(RGFDemo:null).ExecuteSQLFile legacy/import.sql
GO

RgfCmd.IfVersion(RGFDemo:null).Import RGFDemo/rgf_menu.json
GO

RgfCmd.IfVersion(RGFDemo:null).ExecuteSQLFile 1.0/import-1.0.sql
GO

RgfCmd.IfVersion(RGFDemo:1.0).ExecuteSQLFile 1.1/import-1.1.sql
GO
