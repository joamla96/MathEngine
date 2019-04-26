#!/bin/bash

IFS=','
while read p; do
	read -ra params <<< "$p"
	
	decimals="${params[0]}"
	totalReqs="${params[1]}"
	concurReqs="${params[2]}"
	
	echo "Executing, Concurrent: $concurReqs Total: $totalReqs"
	
	ab -n $totalReqs -c $concurReqs -m GET $1 >> result.txt
done < requests.csv
