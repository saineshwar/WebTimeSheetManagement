CREATE QUEUE [dbo].[SqlQueryNotificationService-d78299b8-77ec-4dae-93fc-8e458c0b2e45]
    WITH ACTIVATION (STATUS = ON, PROCEDURE_NAME = [dbo].[SqlQueryNotificationStoredProcedure-d78299b8-77ec-4dae-93fc-8e458c0b2e45], MAX_QUEUE_READERS = 1, EXECUTE AS OWNER);

