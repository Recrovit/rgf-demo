

RgfCmd.ExecuteSQLFile init-recrotrack.sql
GO


RgfCmd.ExecuteSQLFile import-recrodict.sql
GO

RgfCmd.Import.Update RGFDemo/1.0/entities.json
GO

RgfCmd.Import.Update RGFDemo/1.0/category_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/customer_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/customercustomerdemo_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/customerdemographic_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/employee_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/employeeterritory_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/order_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/orderdetail_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/product_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/region_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/shipper_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/supplier_entity.json
GO

RgfCmd.Import.Update RGFDemo/1.0/territory_entity.json
GO


RgfCmd.Import RGFDemo/1.0/rgfdemo_menu.json
GO


RgfCmd.SetVersion(RGFDemo:1.0)
GO
