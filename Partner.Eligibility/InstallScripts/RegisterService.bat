﻿@echo off
echo Registering service...
netsh http add urlacl url=http://+:9123/EligibilityService user=DOMAIN\username