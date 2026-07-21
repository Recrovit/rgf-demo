

RgfCmd.ExecuteSQLFile init-recrotrack.sql
/


RgfCmd.ExecuteSQLFile import-recrodict.sql
/

RgfCmd.Import.Update RGFDemo/1.0/entities.json
/

RgfCmd.Import.Update RGFDemo/1.0/category_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/customer_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/customercustomerdemo_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/customerdemographic_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/employee_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/employeeterritory_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/order_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/orderdetail_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/product_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/region_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/shipper_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/supplier_entity.json
/

RgfCmd.Import.Update RGFDemo/1.0/territory_entity.json
/


RgfCmd.Import RGFDemo/1.0/rgfdemo_menu.json
/


RgfCmd.SetVersion(RGFDemo:1.0)
/
