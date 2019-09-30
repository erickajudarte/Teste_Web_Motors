If Exists (Select * from sys.objects Where object_id = OBJECT_ID(N'[dbo].[DEL_ANUNCIO]') And type in (N'P',N'PC'))
BEGIN
	DROP PROCEDURE DEL_ANUNCIO
END
GO
CREATE PROCEDURE DEL_ANUNCIO
	@ID_ANUNCIO		int

AS
BEGIN
	DELETE FROM tb_AnuncioWebmotors
	WHERE ID  = @ID_ANUNCIO 
END