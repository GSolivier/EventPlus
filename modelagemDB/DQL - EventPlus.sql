SELECT
	Usuario.Nome,	
	TipoDeUsuario.TituloTipoDeUsuario AS Usuario,
	Evento.DataEvento AS [Data do evento],
	CONCAT(Instituicao.NomeFantasia,' - ',Instituicao.Endereco) AS [Local do evento],
	TipoDeEvento.TituloTipoDeEvento AS Assunto,
	Evento.Nome AS [Nome do Evento], 
	Evento.Descricao AS [Descrição do evento],
	CASE WHEN InscricaoEvento.Situacao = 1 THEN 'Presente' ELSE 'Ausente' END AS Participação,
	Comentario.Descricao AS Comentário
FROM
		Usuario
	LEFT JOIN
		TipoDeUsuario ON Usuario.IdTipoDeUsuario = TipoDeUsuario.IdTipoDeUsuario
	LEFT JOIN
		InscricaoEvento ON Usuario.IdUsuario = InscricaoEvento.IdUsuario
	LEFT JOIN
		Evento ON Evento.IdEvento = InscricaoEvento.IdEvento
	LEFT JOIN
		Instituicao ON Instituicao.IdInstituicao = Evento.IdInstituicao
	LEFT JOIN
		TipoDeEvento ON TipoDeEvento.IdTipoDeEvento = Evento.IdEvento
	RIGHT JOIN
		Comentario ON Comentario.IdUsuario = 1



