#!/usr/bin/env python
# -*- coding: utf-8 -*-
#
# utils.py - Common helper methods.
#
# Copyright (c) Five Color Stone
#


"""
Common helper methods.
"""

import os
import redis
from ipaddress import ip_network


def new_redis_conn(db=0):
    """
    Returns new instance of Redis connection with the right db selected.
    """
    socket = os.environ.get('REDIS_SOCKET', "/tmp/redis.sock")
    password = os.environ.get('REDIS_PASSWORD', None)
    return redis.StrictRedis(db=db, password=password, unix_socket_path=socket)


def get_keys(redis_conn, pattern, count=500):
    """
    Returns Redis keys matching pattern by iterating the keys space.
    """
    keys = []
    cursor = 0
    while True:
        (cursor, partial_keys) = redis_conn.scan(cursor, pattern, count)
        keys.extend(partial_keys)
        if cursor == 0:
            break
    return keys


def ip_to_network(address, prefix):
    """
    Returns CIDR notation to represent the address and its prefix.
    """
    network = ip_network(unicode("{}/{}".format(address, prefix)),
                         strict=False)
    return "{}/{}".format(network.network_address, prefix)
