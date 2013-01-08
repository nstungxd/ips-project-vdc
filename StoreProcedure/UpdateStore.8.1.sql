create or replace PROCEDURE usp_nam_kehoachvon
( id_duan in number 
  , ma_donvi_thuchien varchar2
  , cs_lke out pht_type.cs_type
) AS
  b_loi varchar2(100);
BEGIN
-- todo: check quyen - lam sau
  open cs_lke for 
    select distinct nam from bdt_qldt_khdt_tr where ma_dvi= ma_donvi_thuchien and so_id= id_duan;
  
  exception when others then raise_application_error(-20105,b_loi);
END usp_nam_kehoachvon;
