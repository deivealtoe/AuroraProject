CREATE USER aurora_project_user WITH PASSWORD 'MyPostgres:03_';

CREATE SCHEMA aurora_project_schema;

GRANT ALL ON SCHEMA aurora_project_schema TO aurora_project_user;
