all: libffmpeghelper.so

libffmpeghelper.so: videodecoding.o
	g++ -g -shared -o libffmpeghelper.so videodecoding.o -lavcodec -lavdevice -lavfilter -lavformat -lavutil -lpostproc -lswresample -lswscale

videodecoding.o:
	g++ -std=c++11 -fPIC -g -Wall -c videodecoding.cpp

clean:
	rm videodecoding.o libffmpeghelper.so

