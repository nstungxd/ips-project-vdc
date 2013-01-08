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

create or replace
procedure usp_DanhSach_KHV 
( ma_donvi varchar2,nsd varchar2,pas varchar2
, ma_donvi_thuchien varchar2
, nam_khv in number  
, id_duan in number 
, cs_lke out pht_type.cs_type
) as 
b_loi varchar2(100);
begin
-- todo: check quyen - lam sau

open cs_lke for 
  select a.dot,a.so_qd,nvl(a.td_noi,0) td_noi,nvl(a.td_ngoai,0) td_ngoai,a.xoa khv_xoa,b.so_id giamsat_id,b.ma_gd_khv,b.ma_kq_gs,b.ghi_chu
    from bdt_qldt_khdt_tr a
    left join gs_khv b on a.ma_dvi=b.ma_dvi and a.nam = b.nam 
    and a.dot=b.dot and a.so_id = b.so_id_da and a.so_qd = b.so_qd
    where a.ma_dvi= ma_donvi_thuchien and a.nam = nam_khv and a.so_id = id_duan 
    and a.tinh_trang = 1 and a.trinh='D' and a.xoa != 2 order by dot;
exception when others then raise_application_error(-20105,b_loi);
end usp_DanhSach_KHV;
 
