# -*- coding: utf-8 -*-
"""
Created on Thu Dec 10 13:02:28 2020

@author: Windink
"""
import math
import numpy as np
import random
import matplotlib.pyplot as plt
# from imagUnit import load_data 

def classify(images,lables):
    imgs = []
    labs = []							
    for k,img in enumerate(images):
        res = []					
        zhi = 0
        for i in range(len(images)):
            if i == k:
                continue
            image_sub = np.subtract(images[i],img)
            image_pow = np.power(image_sub,2)
            zhi = np.sum(image_pow) 
            result = math.sqrt(zhi)						
            res.append([result,i])
        res = np.array(res)
        index = np.argmin(res,axis = 0)
        indmin = np.min(res,axis = 0)
        #print(index)
        image_new = features_add(img,images[index[0]])
        image_new2 = inside_insert(img,images[index[0]])
        image_new3 = inside_inse(img,images[index[0]])
        #print(res.shape)
        mun = math.sqrt(np.sum(np.power(image_new2 - img,2)))
        mun2 = math.sqrt(np.sum(np.power(image_new - img,2)))
        mun3 = math.sqrt(np.sum(np.power(image_new - img,2)))
        
        if mun3 < indmin[0] + 1:
            imgs.append(image_new3)
            labs.append(lables[k])
        
        #Test(image_new,img)
        if mun < indmin[0] + 3:
            imgs.append(image_new2)
            labs.append(lables[k])
            
            
        # if mun2 < indmin[0] + 5:
        imgs.append(image_new)
        labs.append(lables[k])
        
    #imgs = np.array(imgs)    
    #labs = np.array(labs)
    # images.extend(imgs)
    # lables.extend(labs)
    images = np.append(images,imgs,axis = 0)
    lables = np.append(lables,labs,axis = 0)
        
    return images,lables

def features_add(old_img,import_img):
    #print(import_img.shape)
    #print(import_img.size)
    image_c = import_img / import_img.size
    #print(image_c)
    image_v =  0.4 * old_img - image_c
    #print(image_v)
    image_n = (import_img + image_v ) / np.power(import_img + image_v , 2)  #/ math.sqrt(np.sum())
    #print(image_n.shape)
    
    #mun = math.sqrt(np.sum(np.power(image_v - old_img,2)))
    
    #if mun<indmin: 
    #Test(old_img,image_n)
    return image_n

def inside_insert(old_img,import_img):
    
    image_new = old_img + random.random()  * (import_img-old_img) / random.random()
    #image_new = (images[index[0]]-img) * 0.5 + img
    #image_new = (img - images[index[0]]) * 0.5 + img
    #Test(old_img,image_new)
    return image_new
    
def inside_inse(old_img,import_img):
    image_new =  (old_img + random.random() * (import_img-old_img) / random.random() ) / old_img
    #image_new = (images[index[0]]-img) * 0.5 + img
    #image_new = (img - images[index[0]]) * 0.5 + img
    #Test(old_img,image_new)
    return image_new
    

def Test(image,img):
    plt.figure(figsize=(20, 6))
        # display original
        # display reconstruction
    #plt.subplots(1, 2)
    plt.subplot(1, 2, 1)
    
    plt.imshow(image)
    plt.subplot(1, 2, 2)
    plt.imshow(img)
    
      

def Smote_main(image,lable):
    print("Smote:%d"%(len(image)))
    images,lables = classify(image, lable)
    print("Smote:%d"%(len(images)))

    return images,lables





if __name__ == "__main__":
    s = 0
    # images,lables = load_data("data/orl_faces")
    # classify(images, lables)