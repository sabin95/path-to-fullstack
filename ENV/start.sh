#!/bin/bash
mkdir -p /home/node_cache
rm -r /home/project/FE/node_modules
ln -s /home/node_cache /home/project/FE/node_modules
cd /home/project/FE
npm install
sleep infinity