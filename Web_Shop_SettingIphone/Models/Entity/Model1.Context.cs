﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Shop_SettingIphone.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Web_Shop_SettingIphoneEntities : DbContext
    {
        public Web_Shop_SettingIphoneEntities()
            : base("name=Web_Shop_SettingIphoneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Bill_customers> Bill_customers { get; set; }
        public DbSet<Billdetail> Billdetails { get; set; }
        public DbSet<CommentProduc> CommentProducs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CTdonhang> CTdonhangs { get; set; }
        public DbSet<Custumer> Custumers { get; set; }
        public DbSet<Chitiethinh> Chitiethinhs { get; set; }
        public DbSet<DientuCapLoaithuoctinh> DientuCapLoaithuoctinhs { get; set; }
        public DbSet<DientuChitiethinh> DientuChitiethinhs { get; set; }
        public DbSet<DientuDongSp> DientuDongSps { get; set; }
        public DbSet<DientuDungluong> DientuDungluongs { get; set; }
        public DbSet<DientuInfo> DientuInfoes { get; set; }
        public DbSet<DientuLoaithuoctinh> DientuLoaithuoctinhs { get; set; }
        public DbSet<DientuMathang> DientuMathangs { get; set; }
        public DbSet<DientuMenuSitemathang> DientuMenuSitemathangs { get; set; }
        public DbSet<DientuNsx> DientuNsxes { get; set; }
        public DbSet<DientuTinhnang> DientuTinhnangs { get; set; }
        public DbSet<DientuThuoctinh> DientuThuoctinhs { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Donhang> Donhangs { get; set; }
        public DbSet<EmailRegister> EmailRegisters { get; set; }
        public DbSet<Even_Date> Even_Date { get; set; }
        public DbSet<GroupLibrary> GroupLibraries { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupMenuSanPham> GroupMenuSanPhams { get; set; }
        public DbSet<GroupNewMenuSanPhamDetail> GroupNewMenuSanPhamDetails { get; set; }
        public DbSet<GroupNew> GroupNews { get; set; }
        public DbSet<GroupNewsNewsDetail> GroupNewsNewsDetails { get; set; }
        public DbSet<GroupSupport> GroupSupports { get; set; }
        public DbSet<Html> Htmls { get; set; }
        public DbSet<information> information { get; set; }
        public DbSet<Kichthuoc> Kichthuocs { get; set; }
        public DbSet<Khoanggia> Khoanggias { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<MacodeKhuyenMai> MacodeKhuyenMais { get; set; }
        public DbSet<Mausac> Mausacs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Nuocsanxuat> Nuocsanxuats { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<quantity_purchased> quantity_purchased { get; set; }
        public DbSet<service_charge> service_charge { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<SlideShow> SlideShows { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Tax_ruler> Tax_ruler { get; set; }
        public DbSet<TB_ThongKe> TB_ThongKe { get; set; }
        public DbSet<Tintuc> Tintucs { get; set; }
        public DbSet<Thanhvien> Thanhviens { get; set; }
        public DbSet<Thuonghieu> Thuonghieux { get; set; }
        public DbSet<Url_thanhtoan> Url_thanhtoan { get; set; }
        public DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<Asp_Excell_GetBy_100DHMoiNhat_Result> Asp_Excell_GetBy_100DHMoiNhat()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetBy_100DHMoiNhat_Result>("Asp_Excell_GetBy_100DHMoiNhat");
        }
    
        public virtual ObjectResult<Asp_Excell_GetBy_10DHMoiNhat_Result> Asp_Excell_GetBy_10DHMoiNhat()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetBy_10DHMoiNhat_Result>("Asp_Excell_GetBy_10DHMoiNhat");
        }
    
        public virtual ObjectResult<Asp_Excell_GetBy_50DHMoiNhat_Result> Asp_Excell_GetBy_50DHMoiNhat()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetBy_50DHMoiNhat_Result>("Asp_Excell_GetBy_50DHMoiNhat");
        }
    
        public virtual ObjectResult<Asp_Excell_GetBy_5DHMoiNhat_Result> Asp_Excell_GetBy_5DHMoiNhat()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetBy_5DHMoiNhat_Result>("Asp_Excell_GetBy_5DHMoiNhat");
        }
    
        public virtual ObjectResult<Asp_Excell_GetBy_Chuaduyet_Result> Asp_Excell_GetBy_Chuaduyet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetBy_Chuaduyet_Result>("Asp_Excell_GetBy_Chuaduyet");
        }
    
        public virtual ObjectResult<Asp_Excell_GetBy_duyet_Result> Asp_Excell_GetBy_duyet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetBy_duyet_Result>("Asp_Excell_GetBy_duyet");
        }
    
        public virtual ObjectResult<Asp_Excell_GetBy_Today_Result> Asp_Excell_GetBy_Today()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetBy_Today_Result>("Asp_Excell_GetBy_Today");
        }
    
        public virtual ObjectResult<Asp_Excell_GetByAll_Result> Asp_Excell_GetByAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Asp_Excell_GetByAll_Result>("Asp_Excell_GetByAll");
        }
    
        public virtual ObjectResult<Nullable<int>> Donhang_Max()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Donhang_Max");
        }
    
        public virtual ObjectResult<Get_DientuCauhinh_Result> Get_DientuCauhinh()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_DientuCauhinh_Result>("Get_DientuCauhinh");
        }
    
        public virtual ObjectResult<Get_DientuThuoctinh_Result> Get_DientuThuoctinh()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_DientuThuoctinh_Result>("Get_DientuThuoctinh");
        }
    
        public virtual ObjectResult<Getmau_Result> Getmau(string idProduct)
        {
            var idProductParameter = idProduct != null ?
                new ObjectParameter("IdProduct", idProduct) :
                new ObjectParameter("IdProduct", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Getmau_Result>("Getmau", idProductParameter);
        }
    
        public virtual int Sanpham_Max()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sanpham_Max");
        }
    
        public virtual ObjectResult<spThongKe_Edit_Result> spThongKe_Edit()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spThongKe_Edit_Result>("spThongKe_Edit");
        }
    
        public virtual ObjectResult<Getmau1_Result> Getmau1(string idProduct)
        {
            var idProductParameter = idProduct != null ?
                new ObjectParameter("IdProduct", idProduct) :
                new ObjectParameter("IdProduct", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Getmau1_Result>("Getmau1", idProductParameter);
        }
    }
}
