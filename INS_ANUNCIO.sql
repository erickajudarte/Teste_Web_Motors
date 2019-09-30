If Exists (Select * from sys.objects Where object_id = OBJECT_ID(N'[dbo].[INS_ANUNCIO]') And type in (N'P',N'PC'))
BEGIN
	DROP PROCEDURE INS_ANUNCIO
END
GO
CREATE PROCEDURE INS_ANUNCIO

	@marca			varchar (45),
	@modelo			varchar (45),
	@versao			varchar (45),
	@ano				INT,
	@quilometragem	INT,
	@observacao		text

AS
BEGIN
	INSERT INTO tb_AnuncioWebmotors
	VALUES
	(
		@marca			
		,@modelo			
		,@versao			
		,@ano			
		,@quilometragem	
		,@observacao		
	)
END