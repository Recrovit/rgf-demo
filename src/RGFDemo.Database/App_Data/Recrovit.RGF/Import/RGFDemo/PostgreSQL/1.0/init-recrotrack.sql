INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'category', 'categoryid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'category');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'customercustomerdemo', 'customercustomerdemoid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'customercustomerdemo');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'customerdemographic', 'customertypeid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'customerdemographic');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'customer', 'customerid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'customer');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'employee', 'employeeid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'employee');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'employeeterritory', 'employeeterritoryid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'employeeterritory');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'orderdetail', 'orderdetailid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'orderdetail');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'order', 'orderid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'order');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'product', 'productid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'product');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'region', 'regionid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'region');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'shipper', 'shipperid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'shipper');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'supplier', 'supplierid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'supplier');
INSERT INTO recrotrack_table("tablename", "tablekeys", "enabled") SELECT 'territory', 'territoryid', true WHERE NOT EXISTS (SELECT 1 FROM recrotrack_table WHERE "tablename" = 'territory');
/*$$*/
