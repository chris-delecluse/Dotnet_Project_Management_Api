create table task
(
    id          uuid default gen_random_uuid(),
    project_key varchar(200) not null,
    name        varchar(250) not null,
    description varchar(500) not null,
    status      varchar(100) not null,
    due_date    timestamp,

    constraint PK_task primary key (id),
    constraint FK_project_task foreign key (project_key) references project (key)
)