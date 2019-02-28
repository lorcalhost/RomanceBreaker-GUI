# -*- coding: utf-8 -*- 
from selenium import webdriver
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
import time
import sys
import datetime
import random
import pyperclip
import config
import randomTime


def morningMessage():
    #Sending message
    global driver
    global bae
    msg = random.choice(config.custom_morning_messages)
    try:
        pyperclip.copy(bae)
        searchbar = driver.find_elements_by_xpath(
            '//*[@id="yDmH0d"]/c-wiz/div/div/div/div/div/div[1]/div[3]/div/div[2]/div[3]')[0]
        searchbar.click()
        time.sleep(1)
        newmessage = driver.find_element_by_xpath(
            '//*[@id="yDmH0d"]/c-wiz/div/div/div/div/div/div[2]/div/div[2]/div/div[2]/div/div/div/div[1]/div/div[1]/input')
        newmessage.send_keys(Keys.CONTROL, 'v')
        msg = random.choice(config.custom_morning_messages)
        pyperclip.copy(msg)
        time.sleep(5)
        newmessage.send_keys(Keys.ENTER)
        time.sleep(6.5)
        message = driver.find_elements_by_xpath(
            '//*[@id="yDmH0d"]/c-wiz/div/div/div/div/div/div[2]/div/div[3]/div/div/div[3]/div[2]/div[1]/div/div[2]/div/div[1]')[0]
        message.send_keys(Keys.CONTROL, 'v')
        message.send_keys(Keys.ENTER)
        print("Message {} successfully sent to {}" .format(msg, bae))
    except:
        print("Problem sending, retrying...")
        morningMessage()
        pass
    return


#Getting username & pwd
bae = sys.argv[1]
time.sleep(5)

driver = webdriver.Chrome("./chromedriver")
driver.get("https://messages.android.com/")
wait = WebDriverWait(driver, 600)

randTimeHour, randTimeMinute = randomTime.new(config.custom_time_interval)

while True:
    if int(datetime.datetime.today().hour) == int(randTimeHour) and int(datetime.datetime.today().minute) == int(randTimeMinute):
        morningMessage()
        randTimeHour, randTimeMinute = randomTime.new(
            config.custom_time_interval)
    time.sleep(60)  # Wait one minute to check if it's #morningtime
