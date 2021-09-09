#!/bin/bash
#Script para solicitar renovaão do Ticket kerberos (Default 10horas)
while true
  do
    kinit -R
    sleep 300
  done &