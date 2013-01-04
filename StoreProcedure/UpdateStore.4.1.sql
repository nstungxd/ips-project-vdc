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
 
 

 create or replace
procedure usp_TimKiem_DuAn
( ma_donvi varchar2,nsd varchar2,pas varchar2,
  ma_duan in varchar2,loai_duan in varchar2,nhom_duan in varchar2,loai_nguonvon number,
  phancap varchar2,ma_donvi_quanly varchar2,ma_donvi_thuchien varchar2,toantu_tongvon varchar2,tongvon number,  
  toantu_nam_bd varchar2,nam_bd number,toantu_nam_kt varchar2,nam_kt number,page_index in number,
  page_size in number, total_record out number,cs_lke out pht_type.cs_type
) AS
	b_loi varchar2(100);
  sql_search varchar2(1000);  
  sql_total varchar2(1000);
begin
  -- todo: check quyen - lam sau
  
  sql_search := 'select ma_dvi,so_id,ma,ten,loai_nguon_von,phancap,nhom_da,nam_bd
    ,nam_kt,tien_qd from ( 
    select a.ma_dvi,a.so_id,a.ma,a.ten,a.loai_nguon_von, a.nhom_da, a.nam_bd, a.nam_kt, a.tien_qd
    ,(case a.phan_cap when ''P'' then ''Phân c?p'' when ''T'' then ''T?p trung'' else ''N/A'' end) phancap
    , row_number() over (order by a.so_id) rownumber
    from bdt_qldt_qddt_da a where xoa = 0 ';
  sql_total := 'select count(*) from (select a.so_id from bdt_qldt_qddt_da a where xoa = 0 ';
  if ma_duan != '' then
    sql_search := sql_search || ' and a.ma = ''' || ma_duan || '''';
    sql_total := sql_total || ' and a.ma = ''' || ma_duan || '''';
  end if;
  if loai_duan != '' then
    sql_search := sql_search || ' and a.loai = ''' || loai_duan || '''';
    sql_total := sql_total || ' and a.loai = ''' || loai_duan || '''';
  end if;
  if nhom_duan != '' then
    sql_search := sql_search || ' and a.nhom_da = ''' || nhom_duan || '''';
    sql_total := sql_total || ' and a.nhom_da = ''' || nhom_duan || '''';
  end if;
  if loai_nguonvon != -1 then
    sql_search := sql_search || ' and a.loai_nguon_von = ' || loai_nguonvon ;
    sql_total := sql_total || ' and a.loai_nguon_von = ' || loai_nguonvon ;
  end if;
  if phancap != '' then
    sql_search := sql_search || ' and a.phan_cap = ''' || phancap || '''';
    sql_total := sql_total || ' and a.phan_cap = ''' || phancap || '''';
  end if;
  if ma_donvi_thuchien != '' then
    sql_search := sql_search || ' and a.ma_dvi = ''' || ma_donvi_thuchien || '''';
    sql_total := sql_total || ' and a.ma_dvi = ''' || ma_donvi_thuchien || '''';
  end if;  
  if ma_donvi_quanly != '' then
    sql_search := sql_search || ' and a.ma_dvi_ql = ''' || ma_donvi_quanly || ''' ';
    sql_total := sql_total || ' and a.ma_dvi_ql = ''' || ma_donvi_quanly || ''' ';
  end if;
  if tongvon != 0 then
    sql_search := sql_search || ' and a.tien_qd ' || toantu_tongvon || ' ' || tongvon ;
    sql_total := sql_total || ' and a.tien_qd ' || toantu_tongvon || ' ' || tongvon ;
  end if;
  if nam_bd != 0 then
    sql_search := sql_search || ' and a.nam_bd ' || toantu_nam_bd || ' ' || nam_bd ;
    sql_total := sql_total || ' and a.nam_bd ' || toantu_nam_bd || ' ' || nam_bd ;
  end if;
  if nam_kt != 0 then
    sql_search := sql_search || ' and a.nam_kt ' || toantu_nam_kt || ' ' || nam_kt ;
    sql_total := sql_total || ' and a.nam_kt ' || toantu_nam_kt || ' ' || nam_kt ;
  end if;
  sql_total := sql_total || ')';
  sql_search := sql_search || ') where rownumber > ' || ((page_index-1) * page_size) || ' and rownumber < ' || ((page_index * page_size) + 1);  
  open cs_lke for sql_search;
  
  EXECUTE IMMEDIATE sql_total into total_record;
  
  exception when others then raise_application_error(-20105,b_loi);
end usp_TimKiem_DuAn;

 
 
 
 create or replace
procedure usp_DanhSach_DuAn
( ma_donvi varchar2,nsd varchar2,pas varchar2
, page_index in number  
, page_size in number 
, total_record out number
, cs_lke out pht_type.cs_type
) AS
	b_loi varchar2(100);
begin
-- todo: check quyen - lam sau

  select count(*) into total_record from (select so_id from bdt_qldt_qddt_da where xoa = 0);
  
  open cs_lke for 
    select ma_dvi,so_id,ma,ten,loai_nguon_von,phancap,nhom_da,nam_bd,nam_kt,tien_qd from (
      select ma_dvi,so_id,ma,ten,loai_nguon_von, nhom_da, nam_bd, nam_kt, tien_qd
      ,(case phan_cap when 'P' then 'Phân c?p' when 'T' then 'T?p trung' else 'N/A' end) phancap
      , row_number() over (order by so_id) rownumber
      from bdt_qldt_qddt_da where xoa = 0) 
    where rownumber > ((page_index-1) * page_size) and rownumber < ((page_index * page_size) +1); 
  
  exception when others then raise_application_error(-20105,b_loi);
end usp_DanhSach_DuAn;

 

