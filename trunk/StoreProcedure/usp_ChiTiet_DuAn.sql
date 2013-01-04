create or replace
procedure usp_ChiTiet_DuAn 
( ma_donvi varchar2,nsd varchar2,pas varchar2 
, id_duan in number 
, ma_donvi_thuchien varchar2
, cs_lke out pht_type.cs_type
) as 
b_loi varchar2(100);
begin
-- todo: check quyen - lam sau

  open cs_lke for 
    select a.ma,a.ten,a.loai,a.nhom_da,a.so_qd,a.loai_nguon_von
      ,(case a.phan_cap when 'P' then 'Phân cấp' when 'T' then 'Tập trung' else 'N/A' end) phan_cap
      ,b.ten ten_donvi_thuchien 
      ,c.ten ten_donvi_quanly
      ,a.tien_qd,a.nam_bd,a.nam_kt
      from BDT_QLDT_QDDT_DA a
      inner join ht_ma_dvi b on a.ma_dvi=b.ma
      left join ht_ma_dvi c on a.ma_dvi_ql=c.ma
      where a.ma_dvi=ma_donvi_thuchien and a.so_id = id_duan and a.xoa = 0;
  
  exception when others then raise_application_error(-20105,b_loi);
end usp_ChiTiet_DuAn;
 
