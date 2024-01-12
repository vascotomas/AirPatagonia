CREATE PROCEDURE [dbo].[spDispatcher_Disable]
@status BIT,
@id INT

AS
BEGIN
	UPDATE dispatcher
	SET active = @status
	WHERE id_dispatcher = @id
END
