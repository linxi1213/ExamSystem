import cv2
import sys
import os
import random
import numpy as np
from sklearn.model_selection import train_test_split
from keras.utils import np_utils
from Smote import Smote_main
from Face_OwnCoding import Own_main
import matplotlib.pyplot as plt

NB_CLASS = 0
IMAGE_SIZE = 64
IMAGE_CLASSES = []
ClASSES_COUNT = 0
ClASSES_COUNT_MAX = 400
INDEX = 0
INDEX_MAX = 400
classfier = cv2.CascadeClassifier("haarcascade_frontalface_alt2.xml")
margin = 20
IMAGE_NAME =["jpg","pgm"]

#全局直方图均衡化
def image_equalizeHist(image):
    clahe = cv2.createCLAHE(3,(8,8))
    img = clahe.apply(image)
    img = cv2.resize(img,(64,64))
    return img
    
#水平翻转
def image_filp(image):
    img = cv2.flip(image,1)
    img = cv2.resize(img,(64,64))
    return img
#亮度提升
def image_brightness_improve(image):
    img = np.uint8(np.clip((image + random.randint(9, 11)),0,255))
    img = cv2.convertScaleAbs(image,alpha=1.2,beta=0)
    img = cv2.resize(img,(64,64))
    return img
#对比度
def image_consca(image):
    img = cv2.convertScaleAbs(image,alpha=1.3,beta=0)
    img = cv2.resize(img,(64,64))
    return img
#亮度降低
def image_brightness_lower(image):
    img = np.uint8(np.clip((image - random.randint(9, 11)),0,255))
    img = cv2.resize(img,(64,64))
    return img

#正则化
def image_normalize(image):
    img =cv2.normalize(image,dst=None,alpha=350,beta=10,norm_type=cv2.NORM_MINMAX)
    img = cv2.resize(img,(64,64))
    return img
#添加高斯噪声
def image_gaussian(image,mean = 0, var = 0.001):
    image = np.array(image/255, dtype=float)
    noise = np.random.normal(mean, var ** 0.5, image.shape)
    out = image + noise
    if out.min() < 0:
        low_clip = -1.
    else:
        low_clip = 0.
    out = np.clip(out, low_clip, 1.0)
    out = np.uint8(out*255)
    #cv.imshow("gasuss", out)
    out = cv2.resize(out,(64,64))
    return out

#添加椒盐噪声
def image_noise(image,prob= 0.1):
    output = np.zeros(image.shape,np.uint8)
    thres = 1 - prob 
    for i in range(image.shape[0]):
        for j in range(image.shape[1]):
            rdn = random.random()
            if rdn < prob:
                output[i][j] = 0
            elif rdn > thres:
                output[i][j] = 255
            else:
                output[i][j] = image[i][j]
    output=cv2.resize(output,(64,64))
    return output 

#截取人脸
def DetectFace(image):
    
    img1 = image
    img2 = cv2.cvtColor(img1, cv2.COLOR_BGR2GRAY)
    
    #print(img1.shape)
    
    faceRects = classfier.detectMultiScale(img2, scaleFactor = 1.2, minNeighbors = 3, minSize = (32, 32))
    if len(faceRects) > 0:            #大于0则检测到人脸                                   
        for faceRect in faceRects:  #单独框出每一张人脸
            x, y, w, h = faceRect                
            y_begin, x_begin = max(y-margin, 0), max(x-margin, 0)
            y_end, x_end = min(y+h+2*margin, img1.shape[0]), min(x+w+2*margin, img2.shape[1])
            
            
            saveImg = img1[y_begin : y_end, x_begin : x_end]
           
            return saveImg



def resize_image(image,height=IMAGE_SIZE,width=IMAGE_SIZE):
    images = DetectFace(image)
    #images = None
    #print(image)
    if images is None:
        images = image
    top, bottom, left, right = (0, 0, 0, 0)
    
    h,w,_=images.shape
    #print(images.shape)
    
    longest_edge=max(h,w)
    if h<longest_edge:
        dh=longest_edge-h
        top=dh//2
        boottom=dh-top
    elif w<longest_edge:
        dw=longest_edge-h
        left=dw//2
        right=dw- left
        
    BALCk=[0,0,0]
    
    constant=cv2.copyMakeBorder(images,top,bottom,left,right,cv2.BORDER_CONSTANT,value=BALCk)
    # img1=cv2.resize(constant,(height,width),interpolation=cv2.INTER_LINEAR)
    # cv2.imshow('INTER_NEAREST',img1)
    # cv2.waitKey(0)
    # cv2.destroyWindow('INTER_NEAREST')
    
    return cv2.resize(constant,(height,width))

def read_path(path_name,ispredict):
    global INDEX,ClASSES_COUNT,ClASSES_COUNT_MAX,INDEX_MAX
    images = []
    labels = []
    for item in os.listdir(path_name):
        if INDEX >=INDEX_MAX or ClASSES_COUNT >= ClASSES_COUNT_MAX:
            break
        full_path=os.path.abspath(os.path.join(path_name,item))
        if os.path.isdir(full_path):
            subimgs,sublbls = read_path(full_path,ispredict)
            images.extend(subimgs)
            labels.extend(sublbls)
        else:
            if item.split(".")[-1] in IMAGE_NAME:
                print("\r当前进度：%d"%(INDEX),end="")
                INDEX+=1
                lbl=full_path.split("\\")[-2]
                if lbl not in IMAGE_CLASSES:
                    IMAGE_CLASSES.append(lbl)
                    ClASSES_COUNT += 1
                img=cv2.imread(full_path)
                
                
                rzimg=resize_image(img)
                
                images.append(rzimg)
                labels.append(lbl)
                
                if ispredict == False:
                    imageadd,labeladd = image_add(rzimg, lbl)
                    images.extend(imageadd)
                    labels.extend(labeladd)
                
    
                
    return images,labels

def image_sprlit(images,labels):
    x_train,y_train = [],[]
    x_test,y_test = [],[]
    
    for i in range(len(images)):
        if (i+10) % 10 == 0:
            #print(i)
            x_train.append(images[i])
            y_train.append(labels[i])
            # print(labels[i])
        else:
            x_test.append(images[i])
            y_test.append(labels[i])  
            #print(labels[i])
            
    return x_train,y_train,x_test,y_test
    


def image_add(image,label):
    images = []
    labels = []
    imagefilp = image_filp(image)
    imagebrightimp = image_brightness_improve(image)
    imagebrightlow = image_brightness_lower(image)
    imagega = image_gaussian(image)
    imageno = image_noise(image)
    imagenor = image_normalize(image)
    #imagesca = image_consca(image)
    
    
    images.append(imagefilp)
    images.append(imagebrightimp)
    images.append(imagebrightlow)
    images.append(imagega)
    images.append(imageno)
    images.append(imagenor)
    #images.append(imagesca)
    
    for i in range(len(images)):
        labels.append(label)
    
    return images,labels

def load_dataset(path_name,ispredict):
    images,labels=read_path(path_name,ispredict)
    print()
    print ("images: %d labels: %d" % (len(images), len(labels)))
    #images = np.array(images)
    print("类别的个数：%s"%(len(IMAGE_CLASSES)))
    return images,labels
    
def cvtLabels(lables):
    ret = []
    for la in lables:
        for k,v in enumerate(IMAGE_CLASSES):
            if v == la:
                ret.append(k)     
    return np.array(ret)

def Test(decoded_imgs):
    n = 10
    plt.figure(figsize=(20, 4))
    for i in range(1,n+1):
     
        # display reconstruction
        ax = plt.subplot(1, n, i )
        plt.imshow(decoded_imgs[i-1])
        plt.gray()
        ax.get_xaxis().set_visible(False)
        ax.get_yaxis().set_visible(False)
        
        
    plt.show()

def load_orldata(path,ispredict = True):
    global NB_CLASS,ClASSES_COUNT,INDEX,IMAGE_CLASSES
    images,lables = load_dataset(path,ispredict)
    print(lables[:10])
    Test(images)
    
    NB_CLASS = len(IMAGE_CLASSES)
    x_train,y_train,x_test,y_test = image_sprlit(images,lables)
    class_count = len(x_train)
    
   
  
    
    for i in range(class_count):
        image_new,labels_new = image_add(x_train[i],y_train[i])
        x_train.extend(image_new)
        y_train.extend(labels_new)
    
    
    x_train = np.array(x_train)
    x_test = np.array(x_test)
    
    y_train = cvtLabels(y_train)
    y_test = cvtLabels(y_test)
   # print(y_train[:10])
   
    y_train = np_utils.to_categorical(y_train,NB_CLASS)
    y_test = np_utils.to_categorical(y_test,NB_CLASS)
   # print(y_train[:10])
    
    x_train = x_train.astype("float32") / 255
    x_test = x_test.astype("float32") / 255
    
    x_train,y_train = Smote_main(x_train,y_train)
    
    # imgs , labs = Own_main(x_train,y_train)
    # x_train = np.append(x_train,imgs,axis = 0)
    # y_train = np.append(y_train,labs,axis = 0)
    
    INDEX =0
    ClASSES_COUNT = 0
    
    return x_train,y_train,x_test,y_test
    

def load_data(path,ispredict = False):
    global NB_CLASS,ClASSES_COUNT,INDEX,IMAGE_CLASSES
    #IMAGE_CLASSES.append("me")
    images,lables = load_dataset(path,ispredict)
    
    # train_images,valid_images,train_lables,valid_lables=train_test_split(
    #                  images,lables,test_size=0.1,random_state=0)
    
    images = np.array(images)
    
    NB_CLASS = len(IMAGE_CLASSES)
    #print(NB_CLASS)
    train_lables = cvtLabels(lables)
    print(train_lables[:10])
    train_lables = np_utils.to_categorical(train_lables,NB_CLASS)
    print(train_lables[:10])
    train_images = images.astype("float32") / 255
    
    INDEX =0
    ClASSES_COUNT = 0
    return train_images,train_lables




if __name__== "__main__":
    path="./data/lfw"
    #imgs,lbs = load_data(path,True)
    x_train,y_train,x_test,y_test = load_orldata("./data/orl_faces")
    #print(imgs)
    #print(lbs)
    #img=cv2.imread('./data/imags/Aaron_Eckhart/Aaron_Eckhart_0001.jpg')
    #resize_image(image=img)

