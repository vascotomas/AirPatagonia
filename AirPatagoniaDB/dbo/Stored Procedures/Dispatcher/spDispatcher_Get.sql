﻿CREATE PROCEDURE [dbo].[spDispatcher_Get]
	@id INT 
	
AS
BEGIN
	SELECT * FROM dispatcher WHERE id_dispatcher = @id
END