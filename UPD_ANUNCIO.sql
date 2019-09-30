If Exists (Select * from sys.objects Where object_id = OBJECT_ID(N'[dbo].[UPD_ANUNCIO]') And type in (N'P',N'PC'))
BEGIN
	DROP PROCEDURE UPD_ANUNCIO
END
GO
CREATE PROCEDURE UPD_ANUNCIO
	@ID_ANUNCIO		int,
	@marca			varchar (45),
	@modelo			varchar (45),
	@versao			varchar (45),
	@ano				INT,
	@quilometragem	INT,
	@observacao		text

AS
BEGIN
	UPDATE tb_AnuncioWebmotors
	SET marca			= @marca			
		,modelo			= @modelo			
		,versao			= @versao			
		,ano			= @ano			
		,quilometragem	= @quilometragem	
		,observacao		= @observacao		
	WHERE ID  = @ID_ANUNCIO
END