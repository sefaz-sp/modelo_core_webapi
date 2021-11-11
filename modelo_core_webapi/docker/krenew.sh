#!/bin/bash
while true
do
  sh klogin.sh
  kinit -R
  sleep 3600
done