RgfCmd.InitialCreate.ExecuteSQLFile northwind.sql
/

--RgfCmd.IfVersion(RGFDemo:null).ExecuteSQLFile legacy/import.sql
/

RgfCmd.IfVersion(RGFDemo:null).Import RGFDemo/rgf_menu.json
/

RgfCmd.IfVersion(RGFDemo:null).ExecuteSQLFile 1.0/import-1.0.sql
/

RgfCmd.IfVersion(RGFDemo:1.0).ExecuteSQLFile 1.1/import-1.1.sql
/
