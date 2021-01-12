# -*- coding: utf-8 -*-
"""
Created on Tue Dec  8 11:09:42 2020

@author: Windink
"""

import keras
from keras.datasets import mnist
import matplotlib.pyplot as plt
from keras.layers import Input, Dense, Conv2D, MaxPooling2D, UpSampling2D,Convolution2D
from keras.models import Model
from keras.optimizers import SGD,Adam
from keras.losses import categorical_crossentropy,binary_crossentropy
import numpy as np



def bulid_en_de_model():
    input_img = Input(shape=(64,64,3))
# encoded部分
    x = Conv2D(32, (3, 3), activation='relu', padding='same')(input_img)
    x = MaxPooling2D((2, 2), padding='same')(x)
    x = Conv2D(16, (3, 3), activation='relu', padding='same')(x)
    encoded = MaxPooling2D((2, 2), padding='same',name="endo1")(x)
    
    encoded_model = Model(input_img,encoded)
    encoded_model.summary()
    
    print(encoded_model.get_layer("endo1").output.shape[-3:])
    decoded_input_img = Input(shape=(encoded_model.get_layer("endo1").output.shape[-3:]))
# decoded部分

    x = UpSampling2D((2, 2))(encoded)
    x = Conv2D(16, (3, 3), activation='relu', padding='same')(x)
    x = UpSampling2D((2, 2))(x)
    x = Conv2D(32, (3, 3), activation='relu', padding='same')(x)
    decoded = Conv2D(3, (3, 3), activation='sigmoid', padding='same')(x)
       
    # decoded_model = Model(decoded_input_img,decoded)
    # decoded_model.summary()

#编码，解码
    autoencoder = Model(input_img,decoded)
    autoencoder.summary()

    return encoded_model,autoencoder

def au_train(encoded_model,decoded_model,x_train):
    encoded_model.compile(optimizer=Adam(lr = 0.01), loss='binary_crossentropy')
    
    decoded_model.compile(optimizer=Adam(lr = 0.01), loss='binary_crossentropy')
    
    # encoded_model_fit = encoded_model.fit(x_train, x_train,nb_epoch=100,batch_size=2,
    #                                   shuffle=True,validation_data=(x_train,x_train),verbose=0)
    
    # encoded_imgs =  encoded_model.predict(x_train)
    
    decoded_model_fit = decoded_model.fit(x_train, x_train,nb_epoch=100,batch_size=32,
                                      shuffle=True,validation_data=(x_train,x_train),verbose=0)
    
    encoded_imgs = encoded_model.predict(x_train)
    decoded_imgs = decoded_model.predict(x_train)
    
    return encoded_imgs,decoded_imgs



def Own_main(images,labels):
    x_train,y_train = images,labels
      
    #load_data(path,ispredict=True)
    #生产随机噪声
    noise_factor = 0.5
    x_train_noisy = x_train + noise_factor * np.random.normal(loc=0.0, scale=1.0, size=x_train.shape) 
    #x_test_noisy = x_test + noise_factor * np.random.normal(loc=0.0, scale=1.0, size=x_test.shape) 
    encoded_model,decoded_model = bulid_en_de_model()
    
    
    encoded_imgs,decoded_imgs = au_train(encoded_model, decoded_model,x_train)
    
    #encoded_noisy_imgs,decoded_noisy_imgs = au_train(encoded_model,decoded_model,x_train_noisy,x_train)
    
    Test(x_train,decoded_imgs)
    #Test(x_train_noisy,decoded_noisy_imgs)
    #images = np.append(decoded_imgs,decoded_noisy_imgs,axis = 0)
    #lables = np.append(y_train,y_train,axis = 0)
    images = decoded_imgs
    lables = y_train
    
    return images,lables
 
   
def Test(x_train,decoded_imgs):
    n = 10
    plt.figure(figsize=(20, 4))
    for i in range(1, n+1):
        # display original
        ax = plt.subplot(3, n, i)
        plt.imshow(x_train[i])
        plt.gray()
        ax.get_xaxis().set_visible(False)
        ax.get_yaxis().set_visible(False)
     
        # display reconstruction
        ax = plt.subplot(3, n, i + n)
        plt.imshow(decoded_imgs[i])
        plt.gray()
        ax.get_xaxis().set_visible(False)
        ax.get_yaxis().set_visible(False)
        
        
    plt.show()

if __name__=="__main__":
    Own_main("data/lfw")    
    