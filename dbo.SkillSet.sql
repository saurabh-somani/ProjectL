CREATE TABLE [dbo].[SkillSet] (
    [StudentID] NUMERIC (18) NOT NULL,
    [Skill]     TEXT         NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID],[Skill])
);

