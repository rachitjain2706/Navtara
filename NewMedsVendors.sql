Use Navtara
Go
Create Procedure NewMedsVendors (@medicine_code varchar(50), @generic_name varchar(50), @trade_name varchar(50), @purchasing_price varchar(50), @selling_price varchar(50), @description varchar(50), @vendor_code varchar(50), @vendor_name varchar(50), @address varchar(50), @med_code varchar(50))
as
insert into medicine values(@medicine_code, @generic_name, @trade_name, @purchasing_price, @selling_price, @description, @vendor_code);
insert into vendor values(@vendor_code, @vendor_name, @address, @med_code);