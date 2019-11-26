# Manusquare Semantic API

This repository contains the OpenAPI implementation of the semantic matchmaking system for the Manusquare project

## Build instructions
Install the docker image for neo4j using the following command:
``` bash
docker run --name neo4j -p7474:7474 -p7687:7687 -d -v <datapath>:/data -v <logpath>:/logs -v <importpath>:/import -v <pluginpath>:/plugins --env NEO4J_AUTH=none neo4j:latest
``` 
For testing (not required for production deployment) install Graphdb using the following repo:

``` bash
docker pull ontotext/graphdb:9.0.0-ee
docker run -p 127.0.0.1:7200:7200 --name manusquare -t ontotext/graphdb:ontotext/graphdb:9.0.0-ee
``` 
### Run
The compose file is located in the root directory and is named docker-compose.yml

The application exposes the following ports:
      - "37389:80"
      - "44343:443"

https://stackoverflow.com/questions/1082580/how-to-build-jars-from-intellij-properly/45303637#45303637