#!/bin/sh

#Script de Entrypoint, que fará a chamada da aplicação Dotnet e renovação de Ticket Kerberos

#Informar o arquivo de DLL que deverá ser carregado
DLL="modelo_core_webapi.dll"

#Script de renovação de Ticket
sh docker/krenew.sh

#Chamada do executavel da Aplicação
dotnet $DLL
