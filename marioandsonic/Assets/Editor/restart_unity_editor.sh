#!/bin/bash

set -eu

function validate_args() {
  if [ $1 -ne 3 ]; then
    echo "$0: line $BASH_LINENO: wrong number of arguments"
    exit 1
  fi
  return 1
}

function start_unity() {
  $(echo $*)
}

validate_args $# || sleep 1s
start_unity $*
