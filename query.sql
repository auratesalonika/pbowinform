create table laptop_aura(
	id_lepi int primary key,
	nama_lepi varchar(20),
	harga_lepi int,
	stok_lepi int
);

create table nama_pembeli_etty(
	id_pembeli serial primary key,
	nama_pembeli varchar(20)
);

create table detail_transaksi(
	id_detail serial primary key,
	laptop_dibeli varchar(20),
	stok_dibeli int
);

select * From laptop_aura
select* from nama_pembeli_etty
select * from detail_transaksi
select laptop_aura.nama_lepi, laptop_aura.harga_lepi, laptop_aura.stok_lepi, nama_pembeli_etty.nama_pembeli, detail_transaksi.laptop_dibeli, detail_transaksi.stok_dibeli from laptop_aura join detail_transaksi on laptop_aura.nama_lepi = detail_transaksi.laptop_dibeli join nama_pembeli_etty ON detail_transaksi.id_detail = nama_pembeli_etty.id_pembeli;

SELECT 
    laptop_aura.nama_lepi,
    laptop_aura.harga_lepi,
    laptop_aura.stok_lepi,
    nama_pembeli_etty.nama_pembeli,
    detail_transaksi.laptop_dibeli,
    detail_transaksi.stok_dibeli
FROM
    laptop_aura
    JOIN detail_transaksi ON laptop_aura.nama_lepi = detail_transaksi.laptop_dibeli
    JOIN nama_pembeli_etty ON detail_transaksi.id_detail = nama_pembeli_etty.id_pembeli;

