RgfCmd.ExecuteSQLFile dbmod.sql
GO

RgfCmd.Import.Update RGFDemo/1.1/RgEmployee_recrodict.json
GO

RgfCmd.Import.Update RGFDemo/1.1/RgOrderDetail_recrodict.json
GO

RgfCmd.Import.Update RGFDemo/1.1/RgCategory.json
GO

RgfCmd.Import.Update RGFDemo/1.1/RgProduct.json
GO

RgfCmd.Import.Update RGFDemo/1.1/RgEmployee.json
GO

RgfCmd.Import.Update RGFDemo/1.1/RgOrder.json
GO

RgfCmd.Import.Update RGFDemo/1.1/RgOrderDetail_ex.json
GO

RgfCmd.Import.Update RgOrder_ex.json
GO

RgfCmd.Import.Update RgOrderDetail_ex.json
GO

RgfCmd.Import.Update RGFDemo/1.1/1997.Sales.Overview.Dashboard.json
GO

RgfCmd.Import.Update RGFDemo/1.1/1997.Sales.Breakdown.Dashboard.json
GO

RgfCmd.SetVersion(RGFDemo:1.1)
GO
