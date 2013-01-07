create or replace
procedure usp_DanhSach_GoiThau
( ma_donvi varchar2,nsd varchar2,pas varchar2
, ma_donvi_thuchien varchar2
, id_duan in number 
, page_index in number
, page_size in number
, total_record out number
, cs_lke out pht_type.cs_type
) as 
b_loi varchar2(100);
tt_xoa number;
id_goithau_xoa number;
begin

-- todo: check quyen - lam sau
  
  -- tinh tong so ban ghi
  select count(*) into total_record from (select a.so_id from bdt_qldt_gth_ct a
          inner join bdt_qldt_gth_ma_htt b on a.hthuc = b.ma 
          and (b.ma_dvi = '100' or a.ma_dvi = b.ma_dvi) -- can chu y dong code nay(check lai du lieu)
          --left join gs_gthau c on a.ma_dvi = c.ma_dvi and a.so_id = c.so_id_gthau 
          where a.xoa!=2 and a.ma_dvi = ma_donvi_thuchien and a.so_id_da = id_duan);
  
  -- danh sach goi thau
  open cs_lke for 
    select a.so_id id_goithau,a.ten ten_goithau,b.ten hinhthuc_dauthau,a.xoa goithau_xoa,c.so_id id_giamsat,c.ma_gd_gthau,c.ma_kq_gs,c.ghi_chu         
          from bdt_qldt_gth_ct a
          inner join bdt_qldt_gth_ma_htt b on a.hthuc = b.ma 
          and (b.ma_dvi = '100' or a.ma_dvi = b.ma_dvi) -- can chu y dong code nay(check lai du lieu)
          left join gs_gthau c on a.ma_dvi = c.ma_dvi and a.so_id = c.so_id_gthau 
          where a.so_id in ( 
            select so_id from (select a.so_id,row_number() over (order by a.so_id) rownumber from bdt_qldt_gth_ct a
              where  a.xoa!=2 and a.ma_dvi = ma_donvi_thuchien and a.so_id_da = id_duan
              ) where rownumber > ((page_index-1) * page_size) and rownumber < ((page_index * page_size) +1))
          order by a.so_id,c.ma_gd_gthau;
   
exception when others then raise_application_error(-20105,b_loi);
end usp_DanhSach_GoiThau;
 
