#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "api_root" --dbname "api_root" <<-EOSQL
    CREATE USER api_slave WITH PASSWORD 'P@$$vv0RD';
    CREATE DATABASE api WITH OWNER 'api_slave';
EOSQL

psql -v ON_ERROR_STOP=1 --username "api_slave" --dbname "api" <<-EOSQL
    CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
EOSQL