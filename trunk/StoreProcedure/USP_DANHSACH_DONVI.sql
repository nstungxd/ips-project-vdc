create or replace PROCEDURE USP_DANHSACH_DONVI
( ma_donvi varchar2,nsd varchar2,pas varchar2
  , cs_lke out pht_type.cs_type
) AS
  b_loi varchar2(100);
BEGIN
-- todo: check quyen - lam sau
  open cs_lke for 
    select ma,ten from ht_ma_dvi order by ten;
  
  exception when others then raise_application_error(-20105,b_loi);
END USP_DANHSACH_DONVI;