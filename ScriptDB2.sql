INSERT INTO Categorias (NombreCategoria)
VALUES('Zapatillas')
INSERT INTO Articulos (NombreArticulo, Descripcion, Precio, Stock, ID_Categoria, ID_Marca)
VALUES ('Zapatillas deportivas', 'Zapatillas para correr Nike', 25000, 50, 9, 1),
       ('Camiseta deportiva', 'Camiseta para entrenamiento Adidas', 10000, 100, 8, 2),
       ('Jeans clásicos', 'Jeans de mezclilla ',30000, 60, 7, 3),
       ('Gorra deportiva ', 'Gorra de béisbol Puma', 8000, 80, 6, 7),
       ('Buzo con capucha', 'Buzo cálido con capucha', 6000, 70, 4, 6);

INSERT INTO Imagenes (Url_Imagen, ID_Articulo)
VALUES ('https://nikearprod.vtexassets.com/arquivos/ids/699261-800-800?v=638229666028100000&width=800&height=800&aspect=true', 1),
		('https://nikearprod.vtexassets.com/arquivos/ids/699463-1200-1200?v=638229692034600000&width=1200&height=1200&aspect=true', 1),
       ('https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c0b5234b4053469285dea83500d56eda_9366/Remera_3_Tiras_Blanco_CW1203_01_laydown.jpg', 2),
       ('https://levisarg.vtexassets.com/arquivos/ids/593707/272_6310356e0eb94.jpg?v=637976702233070000', 3),
       ('https://sporting.vtexassets.com/arquivos/ids/300847-1200-1200?width=1200&height=1200&aspect=true', 4),
       ('https://www.stockcenter.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwd6185bf0/products/UBU11L187-1841/UBU11L187-1841-1.JPG', 5);
