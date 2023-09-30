create table project
(
    id          uuid default gen_random_uuid(),
    key         varchar(200) not null unique,
    name        varchar(250) not null,
    description varchar(500) not null,
    start_date  timestamp    not null,
    due_date    timestamp,

    constraint PK_project primary key (id)
)