If Exists (Select * from sys.objects Where object_id = OBJECT_ID(N'[dbo].[SEL_DADOS_ANUNCIO]') And type in (N'P',N'PC'))
BEGIN
	DROP PROCEDURE SEL_DADOS_ANUNCIO
END
GO
CREATE PROCEDURE SEL_DADOS_ANUNCIO

@ID_ANUNCIO INT = NULL
AS
BEGIN
	SELECT
		ID 
		,marca
		,modelo
		,versao
		,ano
		,quilometragem
		,observacao
	FROM tb_AnuncioWebmotors
	WHERE 
		(ID  = @ID_ANUNCIO OR @ID_ANUNCIO IS NULL)

END